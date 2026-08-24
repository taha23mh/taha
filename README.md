"use client";
import { useState } from "react";
import { toPersianNum } from "@/app/data";

const provinceCoords = {
  "تبریز": { x: 10, y: 11 },
  "ارومیه": { x: 12, y: 20 },
  "اردبیل": { x: 20, y: 14 },
  "اصفهان": { x: 48, y: 40 },
  "کرج": { x: 35, y: 29 },
  "ایلام": { x: 13, y: 44 },
  "بوشهر": { x: 35, y: 72 },
  "تهران": { x: 40, y: 30 },
  "شهرکرد": { x: 35, y: 53 },
  "بیرجند": { x: 73, y: 48 },
  "مشهد": { x: 73, y: 25 },
  "بجنورد": { x: 64, y: 18 },
  "اهواز": { x: 25, y: 56 },
  "زنجان": { x: 20, y: 25 },
  "سمنان": { x: 58, y: 30 },
  "زاهدان": { x: 80, y: 80 },
  "شیراز": { x: 45, y: 66 },
  "قزوین": { x: 28, y: 28 },
  "قم": { x: 35, y: 35 },
  "سنندج": { x: 15, y: 28 },
  "کرمان": { x: 65, y: 63 },
  "کرمانشاه": { x: 13, y: 35 },
  "یاسوج": { x: 38, y: 61 },
  "گرگان": { x: 55, y: 18 },
  "رشت": { x: 30, y: 22 },
  "خرم‌آباد": { x: 25, y: 47 },
  "ساری": { x: 43, y: 23 },
  "اراک": { x: 28, y: 38 },
  "بندرعباس": { x: 58, y: 82 },
  "همدان": { x: 22, y: 34 },
  "یزد": { x: 58, y: 52 },
};

export default function IranMap({ provinces, currentCity, onSelectCity }) {
  const [hovered, setHovered] = useState(null);

  if (!provinces.length) {
    return (
      <div className="glass-card p-6 h-full min-h-[300px] flex items-center justify-center">
        <div className="w-full h-64 shimmer"></div>
      </div>
    );
  }

  return (
    <div className="glass-card p-6 h-full relative overflow-hidden">
      <h3 className="text-lg font-bold mb-4 flex items-center gap-2">
        <i className="fa-solid fa-map-location-dot text-amber-400"></i>
        نقشه تعاملی ایران
      </h3>
      <div className="relative w-full aspect-[4/3] rounded-2xl overflow-hidden" style={{ border: "1px solid var(--glass-border)" }}>
        {/* عکس نقشه ایران — فایل رو توی public/images/iran-map.png بذار */}
        <img
          src="/images/iran-map.png"
          alt="نقشه ایران"
          className="w-full h-full object-contain"
          draggable={false}
        />

        {/* نقاط شهرها روی عکس */}
        {provinces.map((p) => {
          const coord = provinceCoords[p.capital];
          if (!coord) return null;
          const isActive = currentCity === p.capital;
          return (
            <button
              key={p.id}
              className="map-group"
              style={{ left: `${coord.x}%`, top: `${coord.y}%` }}
              onClick={() => onSelectCity(p.capital, p)}
              onMouseEnter={() => setHovered(p.capital)}
              onMouseLeave={() => setHovered(null)}
            >
              <div className={`map-dot ${isActive ? "active" : ""}`}>
                {isActive && <span className="pulse-ring" style={{ color: "#f5b942" }}></span>}
              </div>
              {(hovered === p.capital || isActive) && (
                <div className="map-label">
                  <span className="font-bold">{p.capital}</span>
                </div>
              )}
            </button>
          );
        })}
      </div>
      <p className="text-xs mt-3 text-center" style={{ color: "var(--text-muted)" }}>
        روی نقاط برای مشاهده آب و هوا کلیک کنید
      </p>
    </div>
  );
}
